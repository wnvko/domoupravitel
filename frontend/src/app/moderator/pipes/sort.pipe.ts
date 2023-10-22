import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'sort'
})
export class SortPipe implements PipeTransform {

  transform(value: any[] | null, field: string): any[] | null {
    if (value) {
      value.sort((x, y) => {
        if (x[field] > y[field]) return 1;
        if (x[field] < y[field]) return -1;
        return 0
      });
    }
    return value;
  }
}
