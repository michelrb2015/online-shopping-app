import { Component, OnInit } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatCardModule } from '@angular/material/card';
import { AppState } from '../../store/reducers';
import { Store } from '@ngrx/store';
import { selectProducts } from '../../store/selectors/product.selector';
import { Product } from '../../shared/models/product.model';
import { Observable } from 'rxjs';
import * as ProductActions from '../../store/actions/product.action';
import { CommonModule } from '@angular/common';
import { Router } from '@angular/router';

@Component({
  selector: 'app-product-list',
  standalone: true,
  imports: [MatButtonModule, MatCardModule, MatIconModule, CommonModule],
  templateUrl: './product-list.component.html',
  styleUrl: './product-list.component.scss'
})
export class ProductListComponent implements OnInit {
  productList$: Observable<Product[]> | undefined;

  constructor(
    private store: Store<AppState>,
    private router: Router
  ) {}
  ngOnInit(): void {
    this.productList$ = this.store.select(selectProducts);

    this.store.dispatch(ProductActions.loadProducts())
  }

  goToCart() {
    this.router.navigate(['cart']);
  }
}
