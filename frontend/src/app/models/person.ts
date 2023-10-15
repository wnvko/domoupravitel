import { PersonDescriptor } from "./person-descriptor";

export interface Person {
    id: string;
    name: string;
    phone: string;
    email: string;
    descriptor: PersonDescriptor;
}