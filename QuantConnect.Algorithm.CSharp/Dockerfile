FROM mono:6.8.0.96

WORKDIR /opt/Lean

RUN apt-get update && apt-get -y install git nuget

# This clones the master branch. This makes me nervous, since it seems they stopped tagging in 2017
# As of this repo, the latest commit is c82ad86. The main reason I'm locking to this is so the
# Algorithm.CSharp.csproj file doesn't get out of date. If you update the master branch, just
# make sure the csproj file is updated and your code files are added to it
RUN git clone https://github.com/QuantConnect/Lean.git /opt/Lean
RUN git checkout c82ad86

# Restore nuget packages
RUN nuget restore QuantConnect.Lean.sln

COPY config.json Launcher/

COPY Algorithm.CSharp.csproj Algorithm.CSharp/QuantConnect.Algorithm.CSharp.csproj
COPY *.cs Algorithm.CSharp/

RUN msbuild QuantConnect.Lean.sln /p:RunTest=false

WORKDIR /opt/Lean/Launcher/bin/Debug/

CMD ["mono", "QuantConnect.Lean.Launcher.exe", "--data-folder", "/opt/Lean/Data", "--config", "/opt/Lean/Launcher/config.json"]
