    export function cleanDate (date: Date): Date {
        return new Date(date.getTime() - date.getTimezoneOffset() * 60000);
    }
