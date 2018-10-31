# Sample cluster application generator

## Example 1

- clusters: between 2 and 10
- threadshould: at least 0.01
- attributes: double, double, integer, boolean

Input file: sample.csv

```bash
app -c 2:10 -t 0.01 -a ddib sample
```
### Options

[Option('c', "clusters", "Number of clusters to use")]

