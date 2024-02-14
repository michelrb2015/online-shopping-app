import { createSelector } from '@ngrx/store';
import { AppState } from '../reducers';

const selectAuth = (state: AppState) => state.auth;

export const isLoggedIn = createSelector(
  selectAuth,
  (auth) => auth.isLoggedIn
);

export const isRegistered = createSelector(
  selectAuth,
  (auth) => auth.isRegistered
);
