import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, catchError, map, of, tap, throwError } from 'rxjs';
import { Product } from '../shared/models/product.model';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  baseProductsUrl = 'http://localhost:5212/api/product/list'
  constructor(private http$: HttpClient) {}

  getProducts(): Observable<Product[]> {
    return this.http$.get<Product[]>(`${this.baseProductsUrl}`).pipe(
      map((response: Product[])=> response),
      catchError(err=>{
        return throwError(()=> new Error(err.error.message));
      })
    );
  }
}
