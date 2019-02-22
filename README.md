# .NET Core C# Generic Controller and Generic Repository

The goal of this repository is to show example of how to take a normal C# .NET Core WebAPI project and transform that project to use a generic controller and generic repository to reduce code and handle any new models (classes) automatically.  This should reduce the amount of code needed and allow the ability to add features and functions calls across all Controllers with less code.

## Projects
There are 3 different projects to show the various stages of the solutions.

1. normal-ctrl-service - Contains a Controller, Interface and Service for each object (class).

2. normal-ctrl-repo - Contains a Controller for each Object but uses a Generic Respository for the Interface and Services.

3. generic-ctrl-repo - Has a Controller for each object that inherits from a Generic controller with a generic repository.