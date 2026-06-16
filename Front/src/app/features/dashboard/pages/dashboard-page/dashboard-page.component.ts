import { Component, inject, signal } from '@angular/core';
import { DashboardService } from '../../services/dasboard.service';
import { DashboardSummary } from '../../interfaces/dashboard.interface';
import { CommonModule } from '@angular/common';
import ApexCharts from 'apexcharts';

@Component({
  selector: 'app-dashboard-page',
  imports: [CommonModule],
  templateUrl: './dashboard-page.component.html',
  styleUrl: './dashboard-page.component.css',
})
export class DashboardPageComponent {
  private dashboardService = inject(DashboardService);

  summary = signal<DashboardSummary | null>(null);
  loading = signal(true);

  ngOnInit() {
    this.dashboardService.getSummary().subscribe({
      next: (data) => {
        this.summary.set(data);
        this.loading.set(false);
        setTimeout(() => this.renderChart(data), 0);
      },
      error: () => this.loading.set(false),
    });
  }

  private renderChart(data: DashboardSummary) {
    const chart = new ApexCharts(document.querySelector('#chart')!, {
      chart: { type: 'bar', height: 250, background: 'transparent' },
      theme: { mode: 'dark' },
      series: [
        {
          name: 'Total',
          data: [data.providers, data.services, data.averageHourlyRate],
        },
      ],
      xaxis: {
        categories: ['Providers', 'Services', 'Avg. Hourly Rate'],
      },
      colors: ['#f472b6'],
      dataLabels: { enabled: false },
      grid: { borderColor: '#ffffff10' },
    });
    chart.render();
  }
}
