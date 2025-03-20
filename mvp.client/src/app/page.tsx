"use client"
import { useAutoAnimate } from '@formkit/auto-animate/react'
import Image from "next/image";
import Link from "next/link";
import { useCallback, useEffect, useState } from "react";
import { Employee } from "./type/types";

export default function Home() {
    const [employees, setEmployees] = useState<Employee[] | null>([])
    const [animationParent] = useAutoAnimate()

      useEffect(() => {
        const fetchCompanies = async () => {
          try {
            const response = await fetch("https://localhost:5001/employees");
            const data: Employee[] = await response.json();
            setEmployees(data);
          } catch (error) {
            console.error("Error fetching companies:", error);
          }
        };
    
        fetchCompanies();
      }, []);


      const search = useCallback(async()=>{
          let query = "https://localhost:5001/employees"
          const filterElement = document.getElementById("searchFilter") as HTMLSelectElement;
          const selectedFilter = filterElement.options[filterElement.selectedIndex].value;

          const inputFilterElement = document.getElementById("inputTextFilter") as HTMLInputElement;
          const inputText = inputFilterElement.value;
 
          console.log("Search text: ", selectedFilter, inputText)

          if(inputText !== "")           
            query = `https://localhost:5001/employees?filter=${selectedFilter}&text=${inputText}`;

          try {
            const response = await fetch(query);
            const data: Employee[] = await response.json();
            setEmployees(data);
          } catch (error) {
            console.error("Error fetching companies:", error);
          }
      }, []);


  return (
    <>
    <nav className="bg-gray-800">
    <div className="mx-auto max-w-7xl px-2 sm:px-6 lg:px-8">
      <div className="relative flex h-16 items-center justify-between">
        <div className="absolute inset-y-0 left-0 flex items-center sm:hidden">

          <button type="button" className="relative inline-flex items-center justify-center rounded-md p-2 text-gray-400 hover:bg-gray-700 hover:text-white focus:ring-2 focus:ring-white focus:outline-hidden focus:ring-inset" aria-controls="mobile-menu" aria-expanded="false">
            <span className="absolute -inset-0.5"></span>
            <span className="sr-only">Open main menu</span>

            <svg className="block size-6" fill="none" viewBox="0 0 24 24" strokeWidth="1.5" stroke="currentColor" aria-hidden="true" data-slot="icon">
              <path strokeLinecap="round" strokeLinejoin="round" d="M3.75 6.75h16.5M3.75 12h16.5m-16.5 5.25h16.5" />
            </svg>
            <svg className="hidden size-6" fill="none" viewBox="0 0 24 24" strokeWidth="1.5" stroke="currentColor" aria-hidden="true" data-slot="icon">
              <path strokeLinecap="round" strokeLinejoin="round" d="M6 18 18 6M6 6l12 12" />
            </svg>
          </button>
        </div>
        <div className="flex flex-1 items-center justify-center sm:items-stretch sm:justify-start">
          <div className="flex shrink-0 items-center">
            <img className="h-8 w-auto" src="https://tailwindcss.com/plus-assets/img/logos/mark.svg?color=indigo&shade=500" alt="Your Company" />
          </div>
          <div className="hidden sm:ml-6 sm:block">
            <div className="flex space-x-4">
             
              <a href="#" className="rounded-md bg-gray-900 px-3 py-2 text-sm font-medium text-white" aria-current="page">Employee</a>
              <a href="#" className="rounded-md px-3 py-2 text-sm font-medium text-gray-300 hover:bg-gray-700 hover:text-white"></a>
              <a href="#" className="rounded-md px-3 py-2 text-sm font-medium text-gray-300 hover:bg-gray-700 hover:text-white">Company</a>
              <a href="#" className="rounded-md px-3 py-2 text-sm font-medium text-gray-300 hover:bg-gray-700 hover:text-white">Department</a>
            </div>
          </div>
        </div>
      </div>
    </div>
    </nav>
    
    <div className="container m-auto">

    <form className="flex flex-col md:flex-row gap-3 mt-12 justify-center">
      <div className="flex">
          <input type="text" placeholder="Search employee" id="inputTextFilter"
        className="w-full md:w-80 px-3 h-10 rounded-l border-2 border-sky-500 focus:outline-none focus:border-sky-500"
        />
          <button type="button" 
            onClick={search}
            className="bg-sky-500 text-white rounded-r px-2 md:px-3 py-0 md:py-1">Search</button>
      </div>
      <select id="searchFilter" name="searchFilter" defaultValue={"name"}
        className=" h-10 border-2 border-sky-500 focus:outline-none focus:border-sky-500 text-sky-500 rounded px-2 md:px-3 py-0 md:py-1 tracking-wider">
        <option value="name" >Name</option>
        <option value="email">Email</option>
        <option value="phone">Phone Number</option>
        </select>
      </form>

      <table className="w-full border-collapse border border-blue-500 mt-16 mx-auto">
      <thead>
        <tr className="bg-blue-500 text-white">
          <th className="py-2 px-4 text-left">First Name</th>
          <th className="py-2 px-4 text-left">Last Name</th>
          <th className="py-2 px-4 text-left">Email</th>
          <th className="py-2 px-4 text-left">Position</th>
          <th className="py-2 px-4 text-left">Hiredate</th>
          <th className="py-2 px-4 text-left">Manager</th>
        </tr>
      </thead>
  <tbody ref={animationParent}>
    {
      employees?.map(employee => <tr key={employee.id} className="bg-white border-b border-blue-500">
        <td className="py-2 px-4">{employee.firstName}</td>
        <td className="py-2 px-4">{employee.lastName}</td>
        <td className="py-2 px-4">{employee.email}</td>
        <td className="py-2 px-4">{employee.position}</td>
        <td className="py-2 px-4">{employee.hireDate.toString()}</td>
        <td className="py-2 px-4">{employee.managerName}</td>
      </tr>)
    }
  </tbody>
</table>
    </div>


    </>
    

  );
}
