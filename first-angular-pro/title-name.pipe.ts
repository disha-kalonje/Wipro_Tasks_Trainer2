import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'titleName'
})
export class TitleNamePipe implements PipeTransform {

  transform(name: string, title: string): string {
    return `${title} ${name}`;
  }

}
