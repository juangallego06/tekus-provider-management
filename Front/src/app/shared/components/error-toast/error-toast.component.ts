import { Component, effect, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ErrorService } from '../../../core/services/error.service';

@Component({
  selector: 'error-toast',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './error-toast.component.html',
})
export class ErrorToastComponent {
  private errorService = inject(ErrorService);
  error = this.errorService.error;

  private timer: ReturnType<typeof setTimeout> | null = null;

  constructor() {
    effect(() => {
      if (this.error()) {
        if (this.timer) clearTimeout(this.timer); // Resetea si llega otro error

        this.timer = setTimeout(() => {
          this.errorService.clear();
        }, 4000); // 4 segundos
      }
    });
  }

  close() {
    if (this.timer) clearTimeout(this.timer);
    this.errorService.clear();
  }
}
