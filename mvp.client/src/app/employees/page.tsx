"use client"
import React, { useEffect, useState } from 'react'
import { Company, Employee } from '../type/types';

const page = () => {

  const [employees, setEmployees] = useState<Employee[] | null>([])

  useEffect(() => {
    const fetchCompanies = async () => {
      try {
        const response = await fetch("https://localhost:5001/employees");
        const data: Employee[] = await response.json();
        console.log("DATA", data)
        setEmployees(data);
      } catch (error) {
        console.error("Error fetching companies:", error);
      }
    };

    fetchCompanies();
  }, []);


  return (
    <div className="flex  gap-6 bg-blue-100">
      <table className="w-full border-collapse border border-blue-500 max-w-xl mt-16 mx-auto">
      <thead>
        <tr className="bg-blue-500 text-white">
          <th className="py-2 px-4 text-left">First Name</th>
          <th className="py-2 px-4 text-left">Last Name</th>
          <th className="py-2 px-4 text-left">Email</th>
          <th className="py-2 px-4 text-left">Position</th>
          <th className="py-2 px-4 text-left">Hiredate</th>
          <th className="py-2 px-4 text-left">Manager</th>
          <th className="py-2 px-4 text-left"></th>
        </tr>
      </thead>
  <tbody>
    {
      employees?.map(employee => <tr key={employee.id} className="bg-white border-b border-blue-500">
        <td className="py-2 px-4">{employee.firstName}</td>
        <td className="py-2 px-4">{employee.lastName}</td>
        <td className="py-2 px-4">{employee.email}</td>
        <td className="py-2 px-4">{employee.position}</td>
        <td className="py-2 px-4">{employee.hireDate.toString()}</td>
        <td className="py-2 px-4">{employee.managerName}</td>
        <td className="py-2 px-4">
          <button>
            Details
          </button>

          <button>
            Edit
          </button>

          <button>
            Delete
          </button>
        </td>
      </tr>)
    }
  </tbody>
</table>
    </div>
  );
}

export default page