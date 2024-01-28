import { Person } from "./person";

export interface Chip {
    id: string;
    number: string;
    disabled: boolean;
    person: Person;
}
