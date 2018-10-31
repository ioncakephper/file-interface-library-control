using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public class Knn
    {
        private int clusterCount;
        private int[] currentItemCluster;

        public Knn()
        {
            InitializeComponent();
        }

        public Knn(int clusterCount) : this()
        {
            ClusterCount = clusterCount;
        }

        private void InitializeComponent()
        {
            Clusters = new List<Cluster>();
            Items = new List<Item>();
            ClusterCount = 2;            
        }

        public int ClusterCount { get { return clusterCount; }  set
            {
                clusterCount = value;
                OnClusterCount(clusterCount, new EventArgs());
            }
        }

        public List<Cluster> Clusters { get; private set; }

        protected virtual void OnClusterCount(int clusterCount, EventArgs e)
        {
            Clusters.Clear();
            for (int i = 0; i < clusterCount; i++)
            {
                Clusters.Add(new Cluster());
            }
            ClusterCountChanged?.Invoke(this, e);
        }

        public List<Cluster> BuildClusters()
        {
            return BuildClusters(ClusterCount);
        }

        public List<Cluster> BuildClusters(int clusterCount)
        {
            ClusterCount = clusterCount;
            int changes = Int32.MaxValue - 2;
            int totalRuns = 0;
            AllocateItemsToClusters(ClusterCount);
            PlaceItemsInClusters();
            for (totalRuns = 0; totalRuns < int.MaxValue / 2 && changes > 50; totalRuns++)
            {
                changes = 0;
                int index = 0;
                foreach (var item in Items)
                {
                    int calculatedCluster = FindClosestClusterForItem(item);
                    if (calculatedCluster != currentItemCluster[index])
                    {
                        currentItemCluster[index] = calculatedCluster;
                        changes++;
                    }
                    index++;
                }
                if (changes > 0)
                {
                    PlaceItemsInClusters();
                }
            }

            Console.WriteLine("Total runs: "+ totalRuns);
            return Clusters;
        }

        private int FindClosestClusterForItem(Item item)
        {
            List<KeyValuePair<int, double>> distanceToCluster = new List<KeyValuePair<int, double>>();
            int index = 0;
            foreach (var cluster in Clusters)
            {
                double distance = ComputeDistance(cluster.ClusterCentroid, item);
                distanceToCluster.Add(new KeyValuePair<int, double>(index++, distance));
            }
            var orderedDistanceToCluster = distanceToCluster.OrderBy(dc => dc.Value).ToList();
            
            var closestClusters = orderedDistanceToCluster.Select(dc => dc.Key).ToList();
            int closest = closestClusters[0];
            return closest;           
        }

        private double ComputeDistance(ClusterCentroid clusterCentroid, Item item)
        {
            double sum = 0.0;
            int attrCount = item.Items.Length;
            for (int i = 0; i < attrCount; i++)
            {
                sum += Math.Pow(clusterCentroid.Score[i] - item.Items[i], 2.0);
            }
            double r = Math.Sqrt(sum);
            return r;
        }

        private void PlaceItemsInClusters()
        {
            foreach (var cluster in Clusters)
            {
                cluster.Items.Clear();
            }
            for (int i = 0; i < currentItemCluster.Length; i++)
            {
                int clusterIndex = currentItemCluster[i];
                Clusters[clusterIndex].Items.Add(Items[i]);
            }
            foreach (var cluster in Clusters)
            {
                cluster.ComputeCentroid();
            }
        }

        private void AllocateItemsToClusters(int clusterCount)
        {
            Random r = new Random(int.Parse(DateTime.Now.TimeOfDay.Milliseconds.ToString()));
            currentItemCluster = new int[Items.Count];
            for (int i = 0; i < currentItemCluster.Length; i++)
            {
                currentItemCluster[i] = r.Next(0, clusterCount);
            }

        }

        public event EventHandler ClusterCountChanged;

        public List<Item> Items
        {
            get; set;
        }
    }
}
