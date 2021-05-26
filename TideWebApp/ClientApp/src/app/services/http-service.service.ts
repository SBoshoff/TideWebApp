import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { getBaseUrl } from 'src/main';
import { FloodWarning } from '../models/flood-warning.model';

@Injectable({
  providedIn: 'root'
})
export class HttpServiceService {

  constructor(private httpClient: HttpClient) { }

  getFloodWarnings(query: {region: string, pageSize: number, pageNum: number}){
    var url = getBaseUrl() + 'floodwarning?region=' + query.region + '&pagesize=' + query.pageSize + '&pagenum=' + query.pageNum

    return this.httpClient.get<FloodWarning[]>(url);
  }
}
