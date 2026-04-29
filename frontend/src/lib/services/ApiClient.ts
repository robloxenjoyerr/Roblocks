import { Api, type ApiConfig } from "./Api";


const apiConfig: ApiConfig = {
  baseUrl: "http://localhost:5147",
};

const clientInstance = new Api(apiConfig);

export const api = clientInstance.api;
export const client = clientInstance;