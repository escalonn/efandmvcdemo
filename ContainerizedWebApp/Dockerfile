# commands run...
#  1. mkdir ContainerizedWebApp
#  2. cd ContainerizedWebApp
#  3. dotnet new sln
#  4. dotnet new mvc -o ContainerizedWebApp
#  5. dotnet sln add ContainerizedWebApp
#  6. (wrote Dockerfile)
#  7. cd ContainerizedWebApp
#  8. dotnet publish -o ../publish
#  9. cd ..
# 10. docker build -t containerapp:0.1 .

# to start a container, you need an image.
# to build an image, you need a Dockerfile.

# we want to run our MVC app in here.

# when writing a dockerfile, your first step is to choose a base image.
# 1. official vendor images, images with support and constant updates
# 2. images with as much of our app's dependencies already in them as possible
FROM mcr.microsoft.com/dotnet/core/aspnet:2.2

# COPY copies files from outside the image into the image.
COPY ./publish /app

# CMD sets what command will be run to start a container from this image.
CMD [ "dotnet", "/app/ContainerizedWebApp.dll" ]
