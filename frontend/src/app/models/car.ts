import { Property } from "./property";

export interface Car {
    id: string;
    number: string;
    brand: string;
    color: string;
    property: Property;
}