    export function cleanDate (date: Date): Date {
        if (!date) {
            return date;
        }
        return new Date(date.getTime() - date.getTimezoneOffset() * 60000);
    }
