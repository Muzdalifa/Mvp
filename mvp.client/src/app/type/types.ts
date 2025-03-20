export type Company = {
    address :string,
    description : string,
    id: string,
    isActive: boolean,
    name: string,
    website: string
}

export type Employee = {
    id: string,
    firstName: string,
    lastName: string,
    phoneNumber:string,
    email:string,
    position:string,
    managerName:string,
    hireDate:Date,
    companyId:string
}