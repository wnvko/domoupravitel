import { PersonType } from "./enums/person-type";
import { Residence } from "./enums/residence";
import { Person } from "./person";
import { Property } from "./property";

export interface PersonDescriptor {
    id: string;
    personId: string;
    person: Person;
    propertyId: string;
    property: Property;
    personType: PersonType;
    residence: Residence;
    monthsInHouse: number;
    registeredOn?: Date;
    unRegisteredOn?: Date;
}