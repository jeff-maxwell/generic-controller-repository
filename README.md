# .NET Core C# Generic Controller and Generic Repository

The goal of this repository is to show example of how to take a normal C# .NET Core WebAPI project and transform that project to use a generic controller and generic repository to reduce code and handle any new models (classes) automatically.  This should reduce the amount of code needed and allow the ability to add features and functions calls across all Controllers with less code.

## Projects
There are 3 different projects to show the various stages of the solutions.

1. [**normal-ctrl-service**](https://github.com/jeff-maxwell/generic-controller-repository/tree/master/normal-ctrl-service) - Contains a Controller, Interface and Service for each object (class).

2. [**normal-ctrl-repo**](https://github.com/jeff-maxwell/generic-controller-repository/tree/master/normal-ctrl-repo) - Contains a Controller for each Object but uses a Generic Respository for the Interface and Services.

3. [**generic-ctrl-repo**](https://github.com/jeff-maxwell/generic-controller-repository/tree/master/generic-ctrl-repo) - Has a Controller for each object that inherits from a Generic controller with a generic repository.

## Project Stats

|                     | # of Files | Lines of Code (LOC) |
|---------------------|------------|---------------------|
| normal-ctrl-service |     36     |       1,168         |
| normal-ctrl-repo    |     24     |         698         |
| generic-ctrl-repo   |     25     |         459         |

## Project Breakdown

|                     |  Controllers  |     Models    |   Interfaces  |   Services   |
|---------------------|---------------|---------------|---------------|--------------|
|                     | # Files / LOC | # Files / LOC | # Files / LOC | # File / LOC |
| normal-ctrl-service |   7 / 378     |   10 / 127    |    7 / 112    |   8 / 463    |
| normal-ctrl-repo    |   7 / 378     |   10 / 127    |     1 / 17    |    2 / 94    |
| generic-ctrl-repo   |   8 / 139     |   10 / 127    |     1 / 17    |    2 / 94    |

Looking at the breakdown the code saving is Controllers, Interfaces and Sevices with the Models staying the same across all projects and could be externalized into a separate class/assembly.