import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'orderBy'
})
export class OrderByPipe implements PipeTransform {
  transform(value: any[], propertyName: string): any[] {
    if (propertyName) {
      if (typeof value !== 'undefined' && value !== null) {
        return value.sort((a: any, b: any) => b[propertyName].localeCompare(a[propertyName]));
      } else {
        return value;
      }
    } else {
      return value;
    }
  }
}
