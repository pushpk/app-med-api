import { Directive, HostListener } from '@angular/core';

@Directive({
  selector: '[formControlName][appInputMask]',
})
export class InputMaskDirective {
  @HostListener('input', ['$event'])
  onKeyDown(event: KeyboardEvent) {
    const input = event.target as HTMLInputElement;

    const trimmed = input.value.replace(/\s+/g, '').slice(0, 4);
    if (trimmed.length > 3) {
      return (input.value = `${trimmed.slice(0, 2)}/${trimmed.slice(2)}`);
    }
  }
}
