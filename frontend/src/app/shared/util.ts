    export function cleanDate (date: Date): Date {
        if (!date) {
            return date;
        }
        const parsed = new Date(date);
        if (isNaN(parsed.getTime())) {
            return date;    
        }
        return new Date(parsed.getTime() - parsed.getTimezoneOffset() * 60000);
    }
