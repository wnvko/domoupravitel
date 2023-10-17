import { PersonType } from "./enums/person-type";
import { Residence } from "./enums/residence";
import { Person } from "./person";
import { Property } from "./property";

export interface PersonDescriptor {
    id: string;
    person: Person;
    property: Property;
    type: PersonType;
    residence: Residence;
    monthsInHouse: number;
    registeredOn?: Date;
    unRegisteredOn?: Date;
}