import { Car } from "./car";
import { PropertyType } from "./enums/property-type";
import { PersonDescriptor } from "./person-descriptor";
import { Pet } from "./pet";

export interface Property {
    id: string;
    type: PropertyType;
    number: string;
    share: number;
    people: PersonDescriptor[];
    pets: Pet[];
    cars: Car[];
}