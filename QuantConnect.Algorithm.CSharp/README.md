# QuantConnect Docker Example

How to run QuantConnect without having to download Lean and build locally. The solution contains the nuget
packages so autocomplete still works.

1. Create your algorithm file. Make sure the namespace is `QuantConnect.Algorithm`. See `NabeelTestAlgo.cs`
2. Add your cs file to the `Algorithm.CSharp.csproj` file, in the `<Compile Include="..." />` section
3. Edit the `config.json` file (your algorithm file, the API key)
4. Compile and run with Docker:

```bash
docker build -t quantconnect:latest .
docker run quantconnect:latest
```

To run with docker-compose, which mounts the `Results` directory locally, use:

```
docker-compose run backtest
```

If you're running live, use:

```
docker-compose up
```

And the container will restart itself.

---

## NOTE ABOUT THE MASTER BRANCH

This clones the master branch. This makes me nervous, since it seems QuantConnect stopped tagging in 2017. 
As of this repo, the latest commit is `c82ad86`, which is what the container checks out. The main reason 
I'm locking to this is so the `Algorithm.CSharp.csproj` file doesn't get out of date. If you update the 
master branch, just make sure the csproj file is updated and your code files are added to it
