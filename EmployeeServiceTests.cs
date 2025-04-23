using System.Threading.Tasks;
using Xunit;
using Microsoft.EntityFrameworkCore;
using DatabaseSchema.DataBaseContext;
using DatabaseSchema.Repositories;
using DatabaseSchema.Services;
using DatabaseSchema.Model;

namespace DatabaseSchema.Tests
{
    public class EmployeeServiceTests
    {
        private EmployeeContext CreateContext()
        {
            var options = new DbContextOptionsBuilder<EmployeeContext>()
                .UseInMemoryDatabase(databaseName: "TestDb")
                .Options;
            return new EmployeeContext(options);
        }

        [Fact]
        public async Task AddEmployeeAsync_Should_AddEmployeeToContext()
        {
            
            await using var context = CreateContext();
            var repo = new EmployeeRepository(context);
            var service = new EmployeeService(repo);

            
            await service.AddEmployeeAsync(1, "Alice", 100);

           
            var emp = await context.Employees.FindAsync(1);
            Assert.NotNull(emp);
            Assert.Equal("Alice", emp!.Name);
            Assert.Equal(100m, emp.Salary);
        }

        [Fact]
        public async Task GetEmployeeAsync_Should_ReturnEmployee_WhenExists()
        {
           
            await using var context = CreateContext();
            
            context.Employees.Add(new Employee { Id = 2, Name = "Bob", Salary = 200 });
            await context.SaveChangesAsync();

            var repo = new EmployeeRepository(context);
            var service = new EmployeeService(repo);

            
            var emp = await service.GetEmployeeAsync(2);

            
            Assert.NotNull(emp);
            Assert.Equal("Bob", emp!.Name);
            Assert.Equal(200m, emp.Salary);
        }
    }
}