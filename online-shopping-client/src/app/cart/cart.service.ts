import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable, catchError, map, of, throwError } from 'rxjs';
import { Product } from '../shared/models/product.model';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class CartService {
  private cartItemsSubject: BehaviorSubject<Product[]> = new BehaviorSubject<Product[]>([]);
  public cartItems$: Observable<Product[]> = this.cartItemsSubject.asObservable();

  baseCartUrl = 'http://localhost:5212/api/cart'
  baseOrderUrl = 'http://localhost:5212/api/order/place-order'

  constructor(private http$: HttpClient) { }

  addToCart(product: Product, userId: number): Observable<any> {
    return this.http$.post(`${this.baseCartUrl}/add`, { productId: product.id, userId}).pipe(
      map((response: any)=> console.log(response)),
      catchError(err=>{
        return throwError(()=> new Error(err.error.message));
      })
    );
  }

  removeFromCart(product: Product, userId: number): Observable<any> {
    return this.http$.post(`${this.baseCartUrl}/remove`, { productId: product.id, userId}).pipe(
      map((response: any)=> console.log(response)),
      catchError(err=>{
        return throwError(()=> new Error(err.error.message));
      })
    );
  }

  getCartItems(userId: number): Observable<Product[]> {
    return this.http$.get(`${this.baseCartUrl}/${userId}`).pipe(
      map((response: any)=> response),
      catchError(err=>{
        return throwError(()=> new Error(err.error.message));
      })
    );
  }

  placeOrder(userId: number): Observable<any> {
    return this.http$.post(`${this.baseOrderUrl}`, { userId }).pipe(
      map((response: any)=> console.log(response)),
      catchError(err=>{
        return throwError(()=> new Error(err.error.message));
      })
    );
  }
}
