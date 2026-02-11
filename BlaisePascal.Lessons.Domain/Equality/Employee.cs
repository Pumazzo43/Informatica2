using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.Lessons.Domain.Equality
{
    public class Employee : IEquatable<Employee>
    {
        public string Account { get; set; }
        public string Name { get; set; }
        public Employee()
        {

        }
        public Employee(string account, string name)
        {
            this.Account = account;
            this.Name = name;
        }
        public override bool Equals(object? obj)
        {
            Employee? e = obj as Employee;
            return Equals(e);

        }
        public override int GetHashCode()
        {
            return this.Account.GetHashCode();
        }

        public bool Equals(Employee? other)
        {
            if (other != null)
            {
                return other.Account == this.Account;
            }
            return false;
        }

        public static bool operator ==(Employee e1, Employee e2)
        {
            return e1.Account == e2.Account;
        }
        public static bool operator !=(Employee e1, Employee e2)
        {
            return e1.Account != e2.Account;
        }
    }
}
