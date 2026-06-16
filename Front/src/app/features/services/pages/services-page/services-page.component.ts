import { Component, inject, OnInit, signal } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule, FormBuilder, Validators } from '@angular/forms';
import { ServicesService } from '../../services/services.service';
import { ProvidersService } from '../../../providers/services/providers.service';
import { Service } from '../../interfaces/service.interface';
import { Provider } from '../../../providers/interfaces/provider.interface';

@Component({
  selector: 'app-services-page',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './services-page.component.html',
})
export class ServicesPageComponent implements OnInit {
  private servicesService = inject(ServicesService);
  private providersService = inject(ProvidersService);
  private fb = inject(FormBuilder);

  services = signal<Service[]>([]);
  providers = signal<Provider[]>([]);
  loading = signal(true);
  saving = signal(false);

  form = this.fb.group({
    name: ['', Validators.required],
    hourlyRate: [
      null as number | null,
      [Validators.required, Validators.min(0)],
    ],
    providerId: [null as number | null, Validators.required],
  });

  ngOnInit() {
    this.loadServices();
    this.providersService
      .getAll()
      .subscribe((data) => this.providers.set(data));
  }

  loadServices() {
    this.loading.set(true);
    this.servicesService.getAll().subscribe({
      next: (data) => {
        this.services.set(data);
        this.loading.set(false);
      },
      error: () => this.loading.set(false),
    });
  }

  openModal() {
    this.form.reset();
    (
      document.getElementById('modal_create_service') as HTMLDialogElement
    ).showModal();
  }

  closeModal() {
    (
      document.getElementById('modal_create_service') as HTMLDialogElement
    ).close();
  }

  submit() {
    if (this.form.invalid) {
      this.form.markAllAsTouched();
      return;
    }
    this.saving.set(true);

    this.servicesService.create(this.form.value as any).subscribe({
      next: () => {
        this.closeModal();
        this.loadServices();
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
