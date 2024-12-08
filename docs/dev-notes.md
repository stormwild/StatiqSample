# Developer Notes

Notes on how I set up the project and how I solved some of the problems I encountered.

## Initial Setup Steps

Initial files added:

- `StatiqSample/StatiqSample.sln`
- `gitignore`
- `globaljson`
- `editorconfig`
- `nugetconfig`
- `buildprops -> Directory.Build.props`
- `Directory.Packages.props`
- `README.md`
- `docs/dev-notes.md`

1. **Create a `.gitignore` file**:
   - **Command**: `dotnet new gitignore`
   - **Description**: Excludes files and directories that should not be committed to the repository, such as build outputs, user-specific files, and other temporary files.

2. **Create a `global.json` file**:
   - **Command**: `dotnet new globaljson`
   - **Description**: Specifies the .NET SDK version to use for the project, ensuring consistency across different development environments.

   - **Example**:

     ```json
     {
       "sdk": {
         "version": "9.0.101"
       }
     }
     ```

3. **Create an `.editorconfig` file**:
   - **Command**: `dotnet new editorconfig`
   - **Description**: Defines coding styles and conventions for the project, helping maintain a consistent code style across different editors and IDEs.
   - **Note**: You may need to customize the `.editorconfig` file to match your preferred coding style.
   - **Reference**: [.editorconfig documentation](https://editorconfig.org/)
   - **Reference**: [C# Coding Conventions](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/inside-a-program/coding-conventions)
   - **Reference**: [C# Coding Style Guide](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/inside-a-program/coding-style-conventions)
   - **Example**

     Shows differences with the default template:

     ```ini
     # .editorconfig

     # Top-most EditorConfig file
     root = true

     # New line preferences
     insert_final_newline = true
     
     #### C# Coding Conventions ####
     [*.cs]

     # Code-block preferences
     dotnet_style_namespace_declarations = file_scoped:error

     # 'using' directive preferences
     csharp_using_directive_placement = outside_namespace:error
     ```

4. **Create a `nuget.config` file**:
   - **Command**: `dotnet new nugetconfig`
   - **Description**: Configures NuGet package sources and settings, allowing specification of custom package sources or other NuGet-related configurations.
   - **Example**:

     ```xml
     <?xml version="1.0" encoding="utf-8"?>
     <configuration>
       <packageSources>
         <add key="nuget.org" value="https://api.nuget.org/v3/index.json" />
       </packageSources>
     </configuration>
     ```

5. **Create a `Directory.Build.props` file**:
   - **Command**: `dotnet new buildprops`
   - **Description**: Defines common MSBuild properties for the project, applying properties to all projects in the solution.
   - **References** [Directory.Build.props](https://docs.microsoft.com/en-us/visualstudio/msbuild/customize-your-build?view=vs-2022#directorybuildprops-and-directorybuildtargets)
   - [Additional Notes](build-props.md)

6. **Create a `Directory.Packages.props` file**:
   - **Command**: `cp Directory.Build.props Directory.Packages.props`
   - **Description**: Manages NuGet package versions centrally, specifying package versions that apply to all projects in the solution.
   - **Note**: This file can be used to define common package versions for all projects in the solution. There currently isn't a dotnet new template for packagesprops, so you can copy the `Directory.Build.props` file and rename it to `Directory.Packages.props` and modify as shown below.
   - **Example**:

     ```xml
     <Project>
       <PropertyGroup>
         <ManagePackageVersionsCentrally>true</ManagePackageVersionsCentrally>
       </PropertyGroup>
       <ItemGroup>
         <!-- Example entry added automatically when calling dotnet add package <package-name> for projects added to the solution -->
         <PackageVersion Include="xunit" Version="2.5.3" />
         <PackageVersion Include="xunit.runner.visualstudio" Version="2.5.3" />
       </ItemGroup>
     </Project>
     ```

7. **Create a `README.md` file**:
   - **Command**: `touch README.md`
   - **Description**: Provides an overview of the project, including information about the project, how to set it up, and how to contribute.

8. **Create a `docs/dev-notes.md` file**:
   - **Command**:

     ```sh
     mkdir docs && cd docs && touch dev-notes.md
     ```

   - **Description**: Documents notes on how the project was set up and any problems encountered, providing additional context and guidance for developers working on the project.
