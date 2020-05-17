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

See the Dockerfile for more notes. You can also setup a docker-compose file and mount the results and data directories locally.
