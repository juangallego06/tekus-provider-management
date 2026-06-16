import { Component, inject, OnInit, signal } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule, FormBuilder, Validators } from '@angular/forms';
import { ProvidersService } from '../../services/providers.service';
import { Provider } from '../../interfaces/provider.interface';

@Component({
  selector: 'app-providers-page',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './providers-page.component.html',
})
export class ProvidersPageComponent implements OnInit {
  private providersService = inject(ProvidersService);
  private fb = inject(FormBuilder);

  providers = signal<Provider[]>([]);
  loading = signal(true);
  saving = signal(false);

  form = this.fb.group({
    nit: ['', [Validators.required]],
    name: ['', [Validators.required]],
    email: ['', [Validators.required, Validators.email]],
    website: ['', [Validators.required]],
  });

  ngOnInit() {
    this.loadProviders();
  }

  loadProviders() {
    this.loading.set(true);
    this.providersService.getAll().subscribe({
      next: (data) => {
        this.providers.set(data);
        this.loading.set(false);
      },
      error: () => this.loading.set(false),
    });
  }

  openModal() {
    this.form.reset();
    (
      document.getElementById('modal_create_provider') as HTMLDialogElement
    ).showModal();
  }

  closeModal() {
    (
      document.getElementById('modal_create_provider') as HTMLDialogElement
    ).close();
  }

  submit() {
    if (this.form.invalid) {
      this.form.markAllAsTouched();
      return;
    }
    this.saving.set(true);

    this.providersService.create(this.form.value as any).subscribe({
      next: () => {
        this.closeModal();
        this.loadProviders();
        this.saving.set(false);
      },
      error: () => this.saving.set(false),
    });
  }

  isInvalid(field: string) {
    const c = this.form.get(field);
    return c?.invalid && c?.touched;
  }
}
