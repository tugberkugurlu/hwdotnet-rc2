FROM debian:wheezy

RUN apt-get update \
	&& apt-get install -y curl \
	&& rm -rf /var/lib/apt/lists/*

RUN apt-key adv --keyserver hkp://keyserver.ubuntu.com:80 --recv-keys 3FA7E0328081BFF6A14DA29AA6A19B38D3D831EF
RUN apt-key adv --keyserver apt-mo.trafficmanager.net --recv-keys 417A0893

RUN echo "deb [arch=amd64] https://apt-mo.trafficmanager.net/repos/dotnet/ trusty main" > /etc/apt/sources.list.d/dotnetdev.list \
    && echo "deb http://download.mono-project.com/repo/debian beta main" > /etc/apt/sources.list.d/mono-xamarin-beta.list \
	&& apt-get update \
	&& apt-get install -y mono-complete dotnet-dev-1.0.0-preview1-002702 \
    && rm -rf /var/lib/apt/lists/*