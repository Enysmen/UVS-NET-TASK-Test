# TestDataBaseSchema

Unit test project for the **UVS‑NET‑TASK** solution.
Uses **xUnit** and **Entity Framework Core InMemory** to test the business logic of services.
---

## 🎯 Objective

- Provide **isolated** testing of the functionality of working with the `Employee` entity.
- Check the correctness of the methods for adding and getting employees without accessing the real database.

---

## 📂 Project structure

```plain
TestDataBaseSchema/
├─ TestDataBaseSchema.csproj   # xUnit project description
├─ EmployeeServiceTests.cs     # tests for EmployeeService
└─ ...                         # additional tests as needed
```

---

## 🛠 Installing and running tests

1.**Make sure** that the `TestDataBaseSchema` project is included in the `DatabaseSchema.sln` solution.
2. Run tests from the solution root:
   ```bash
  cd <path to solution>
   dotnet test
   ```
3. To run tests from just this project, use:
   ```bash
   dotnet test TestDataBaseSchema/TestDataBaseSchema.csproj
   ```
4.In Visual Studio, open **Test Explorer** (Test → Test Explorer) and click **Run All**.


## ✅ Result

- The tests **pass**, demonstrating that the `EmployeeService` implementation is correct.
- The project can be expanded with additional scenarios and negative test cases.

