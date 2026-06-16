export interface Service {
  id: number;
  name: string;
  hourlyRate: number;
  providerId: number;
  providerName: string;
}

export interface CreateServiceRequest {
  name: string;
  hourlyRate: number;
  providerId: number;
}
