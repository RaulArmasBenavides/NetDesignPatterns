# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Project Overview

**NetDesignPatterns** is a .NET Framework 4.8 solution demonstrating various software design pattern implementations in C#. Each pattern is isolated in its own project for clarity and reusability. The repository serves as both a learning resource and a reference implementation guide for proof-of-concept explorations.

## Quick Start

Get up and running in 3 steps:

```powershell
# 1. Build the entire solution
msbuild "FacadePattern/DesignPatterns.sln" /p:Configuration=Debug

# 2. Run a specific pattern demo (e.g., State pattern)
.\FacadePattern\Pattern.State\bin\Debug\Pattern.State.exe

# 3. Or open in Visual Studio and hit F5 on any Exe project
```

## Solution Structure

The solution file is located at `FacadePattern/DesignPatterns.sln` and contains 12 projects organized by pattern category:

### Facade Pattern Projects
- **FacadePattern.Dominio**: Shared domain model (Employee, Benefit, Incentive)
- **FacadePattern.Fachada**: Facade implementations (EmpleadoFacade, NumbersFacade)
- **FacadePattern.Beneficios**: Benefits business logic
- **FacadePattern.Incentivos**: Incentives business logic
- **FacadePattern.Nomina**: Payroll business logic
- **FacadePattern.ClienteFacturacion**: Console app demonstrating invoicing facade with multiple Programs

### Behavioral Patterns
- **Pattern.State**: State pattern with CoffeeMachine example
- **Pattern.Strategy**: Strategy pattern with PaymentProcessor example
- **Pattern.Observer**: Observer pattern with stock price notification system (Subject notifies multiple Observers of state changes)

### Structural Patterns
- **Pattern.Bridge**: Bridge pattern for notification systems with pluggable senders
- **Pattern.Flyweight**: Flyweight pattern for vehicle type management

### Creational Patterns
- **Pattern.Factory**: Factory pattern implementation
- **Pattern.Memento**: Memento pattern with TextEditor example

## Build & Compilation

### Visual Studio
Open `FacadePattern/DesignPatterns.sln` in Visual Studio and use the standard build commands.

### Command Line (.NET Framework)
```powershell
# Build the entire solution
msbuild "FacadePattern/DesignPatterns.sln" /p:Configuration=Debug

# Build in Release mode
msbuild "FacadePattern/DesignPatterns.sln" /p:Configuration=Release

# Build a specific project
msbuild "FacadePattern/Pattern.State/Pattern.State.csproj" /p:Configuration=Debug
```

## Running Pattern Examples

Several projects have Main() entry points and can be executed directly:

### Console Applications (Exe)
- **Pattern.State**: Coffee machine state management demo
- **Pattern.Strategy**: Payment processor strategy demo
- **Pattern.Bridge**: Notification sender bridge demo
- **Pattern.Factory**: Factory pattern demo
- **Pattern.Memento**: Text editor memento demo
- **Pattern.Flyweight**: Vehicle type flyweight demo
- **Pattern.Observer**: Stock price notification system with dynamic observer attachment
- **FacadePattern.ClienteFacturacion**: Invoicing facade demonstrations

Run from Visual Studio: right-click project → Set as Startup Project → Debug (F5)

Run from command line after building:
```powershell
# Example: Pattern.State
.\FacadePattern\Pattern.State\bin\Debug\Pattern.State.exe
```

### Library Projects
These are non-executable and serve as supporting logic:
- FacadePattern.Dominio
- FacadePattern.Fachada
- FacadePattern.Beneficios
- FacadePattern.Incentivos
- FacadePattern.Nomina

## Project File Configuration

- **Output Type**: Most are `Exe` (runnable console apps) or `Library`
- **Target Framework**: `v4.8` (requires .NET Framework 4.8)
- **Startup Objects**: Each Exe project specifies its entry point (e.g., `Pattern.State.Program`)
- **Assembly Names**: Follow the pattern namespace for clarity

## Architecture Patterns

### Facade Pattern Projects
These demonstrate how a facade simplifies complex subsystem interactions:
- Domain entities are defined in **FacadePattern.Dominio**
- Business logic classes (Bo suffix) handle operations in specialized projects
- **FacadePattern.Fachada** provides unified interfaces to abstract away complexity
- **FacadePattern.ClienteFacturacion** shows real-world usage with multiple Program files demonstrating different scenarios

### Bridge Pattern (Pattern.Bridge)
Decouples notification abstractions from their implementation:
- `INotificationSender` interface allows swappable implementations (EmailSender, SmsSender)
- `Notification` abstract class defines the bridge structure
- Concrete notifications (AlertNotification, ReminderNotification) are independent of how they're sent

### Behavioral Patterns (State, Strategy, Observer)
- **State**: Object behavior changes when internal state changes (CoffeeMachine with different states)
- **Strategy**: Interchangeable algorithms for a single task (PaymentProcessor with payment strategies)
- **Observer**: One-to-many decoupled communication where a Subject notifies multiple Observers of state changes:
  - `StockPrice` (Subject) maintains a list of `IStockObserver` implementations
  - `Investor` (Concrete Observer) reacts to price changes
  - Observers attach/detach dynamically via `Attach()` and `Detach()`
  - Tight loose coupling: Subject changes don't affect observer implementations

## Development Notes

- **Namespace Convention**: Classes follow their assembly name as namespace root (e.g., `Pattern.State`, `ElTavo.FacadePattern.Beneficios`)
- **Entry Points**: Console apps define `Program` class with static `Main(string[] args)` method
- **Project Dependencies**: Some projects reference others (e.g., ClienteFacturacion depends on Dominio, Fachada, and business logic projects)
- **Console Output**: Apps typically use `Console.WriteLine()` for output and `Console.ReadKey()` to keep windows open

## Adding New Patterns (PoC Guide)

When prototyping a new design pattern, follow this structure:

### 1. Create the Project
```powershell
# In Visual Studio: File → New → Project → Class Library (.NET Framework 4.8)
# Name it: Pattern.YourPatternName (for behavioral/structural/creational)
#          or FacadePattern.YourName (for facade-related)
```

### 2. Minimum Structure
```
Pattern.YourPattern/
├── Pattern.YourPattern.csproj          # Target Framework: v4.8, OutputType: Exe
├── Program.cs                          # Entry point with Main()
├── [YourInterface].cs                  # Abstract or interface defining the pattern
├── [ConcreteImpl1].cs                   # First concrete implementation
├── [ConcreteImpl2].cs                   # Second concrete implementation (if applicable)
└── Properties/
    └── AssemblyInfo.cs
```

### 3. .csproj Template (Exe)
Copy from an existing pattern project (e.g., `Pattern.State.csproj`). Key settings:
- `<OutputType>Exe</OutputType>`
- `<TargetFrameworkVersion>v4.8</TargetFrameworkVersion>`
- `<StartupObject>Pattern.YourPattern.Program</StartupObject>`

For library projects (just domain/helper logic), use `<OutputType>Library</OutputType>`.

### 4. Add to Solution
```powershell
# From FacadePattern directory:
dotnet sln DesignPatterns.sln add Pattern.YourPattern/Pattern.YourPattern.csproj
# Or add manually in Visual Studio: File → Add → Existing Project
```

### 5. Naming & Conventions
- **Pattern class/interface**: Name by what it does, not the pattern name (e.g., `Notification`, `PaymentProcessor`)
- **Concrete implementations**: `[AbstractName]Impl1`, `Concrete[Name]`, or domain-specific names
- **Program.cs**: Always use `static void Main(string[] args)` as entry point
- **Namespace**: Use the project name as root namespace

### 6. Example: Adding Observer Pattern
```csharp
// Program.cs
namespace Pattern.Observer
{
    class Program
    {
        static void Main(string[] args)
        {
            var subject = new Subject();
            var observer1 = new ConcreteObserver("Observer 1");
            var observer2 = new ConcreteObserver("Observer 2");
            
            subject.Attach(observer1);
            subject.Attach(observer2);
            subject.Notify("Event occurred");
            
            Console.ReadKey();
        }
    }
}
```

## Testing & Validation

### Manual Testing (Console Apps)
- Run the executable directly and verify console output
- Each pattern demo should print clear, step-by-step results
- Use `Console.WriteLine()` liberally to document the pattern in action

### Validation Checklist
- [ ] Code compiles without warnings (treat warnings as errors during development)
- [ ] Pattern intent is clear from the output (no cryptic behavior)
- [ ] All interfaces/abstract classes are implemented by concrete classes
- [ ] No unused code (each class serves the pattern demonstration)
- [ ] Console output shows before/after or state transitions clearly

### Testing Pattern Logic
For more complex patterns, you can add a `Tests.cs` file within the project:
```csharp
namespace Pattern.YourPattern
{
    class Tests
    {
        static void RunTests()
        {
            // Validation logic here
            Console.WriteLine("[TEST] Scenario 1: ...");
            // Assert behavior
        }
    }
}
```

Then call `Tests.RunTests()` from `Program.Main()` before interactive examples.

### Debugging Tips
- Set startup project: Right-click project → "Set as Startup Project"
- Debug (F5) or run (Ctrl+F5) to test
- Use `System.Diagnostics.Debug.WriteLine()` for debug-only output
- Check console output for state transitions and pattern execution flow
