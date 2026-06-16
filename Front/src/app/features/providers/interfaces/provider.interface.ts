export interface Provider {
  id: number;
  nit: string;
  name: string;
  email: string;
  website: string;
}

export interface CreateProviderRequest {
  nit: string;
  name: string;
  email: string;
  website: string;
}
