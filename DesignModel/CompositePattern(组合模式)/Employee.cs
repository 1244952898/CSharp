using System;
using System.Collections.Generic;
using System.Text;

namespace DesignModel.CompositePattern_组合模式_
{
    internal class Employee
    {
        private string name;
        private string dept;
        private int salary;
        private List<Employee> employees;
        public Employee(string name,string dept,int salary) {
        
            this.name = name;
            this.dept = dept;
            this.salary = salary;
            employees= new List<Employee>();
        }

        public void add(Employee employee)
        {
            employees.Add(employee);
        }

        public void remove(Employee employee)
        {
            employees.Remove(employee);
        }

        public List<Employee> gets()
        {
            return employees;
        }

        public override string ToString()
        {
            return $"Employee :[ Name : ${name}, dept : ${dept} , salary : ${salary} ]";
        }
    }
}
