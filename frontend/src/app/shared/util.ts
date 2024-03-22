import { IGridState, IgxGridComponent } from "@infragistics/igniteui-angular";

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

    export function restoreState(state: IGridState, grid: IgxGridComponent): void {
        state.columns?.forEach(c => {
            const column = grid.columnList.find(col => col.field === c.field);
            if (!column) return;
            column.width = c.width;
          });
          state.sorting?.forEach(s => grid.sort(s));
    }
