# ANSWERS.md — Part G: Short Answer

## 1. `.csproj` Verification

```xml
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>net10.0</TargetFramework>
    <ImplicitUsings>enable</ImplicitUsings>
    <Nullable>enable</Nullable>
  </PropertyGroup>

</Project>
```

**Property Confirmation:**
* `<OutputType>Exe</OutputType>` — Specifies that the project compiles into an executable console application with an entry point.
* `<TargetFramework>net10.0</TargetFramework>` — Defines the target .NET runtime environment for compilation.
* `<ImplicitUsings>enable</ImplicitUsings>` — Automatically imports common global namespaces (such as `System`, `System.Collections.Generic`, `System.Linq`, etc.) to reduce boilerplate code.
* `<Nullable>enable</Nullable>` — Enables C# nullable reference types, enforcing compile-time static analysis for potential null reference warnings.

---

## 2. `#region` / `#endregion` Directives

* **Compiled Output:** No. Directives like `#region` and `#endregion` are processed purely by the compiler preprocessor and IDE tooling. They are completely stripped out during compilation and generate zero CIL (Common Intermediate Language) instructions or performance impact.
* **Why Use Them:** They are used strictly for editor organization and code readability. They allow developers to collapse long blocks of logical code (such as properties, private methods, or interface implementations) within IDEs like Visual Studio or JetBrains Rider.

---

## 3. XML Doc Comments (`///`) vs. Plain Comments (`//`)

* **Plain Comments (`//`):** Intended strictly for internal developer notes explaining **how** or **why** specific implementation logic works inside a method body. They are completely ignored by compiler tooling.
* **XML Doc Comments (`///`):** Used to document public APIs, classes, parameters, return values, and exceptions. You reach for them when:
  * You want rich IntelliSense/hover previews to show description tooltips to consumers of your code across different files or projects.
  * You need to generate external API reference documentation files (like Swagger or HTML docs) using tools like DocFX.

---

## 4. Global Variables in C# & Closest Equivalent

* **Why No True Globals:** C# is an object-oriented language designed around strict encapsulation, modularity, and type safety. Disallowing free-floating global variables prevents scope pollution, unexpected state mutation, and dependency hiddenness across independent assemblies.
* **Closest Equivalent:** `public static` fields or properties defined inside a class (e.g., `public static class AppGlobals { public static string AppName { get; set; } }`). While accessible globally across the project, they still strictly belong to a specific type scope (`AppGlobals.AppName`).