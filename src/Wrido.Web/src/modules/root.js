import { combineEpics } from 'redux-observable';
import { combineReducers } from 'redux';
import { input, status } from './reducers';

export const rootEpic = combineEpics(
);

export const rootReducer = combineReducers({
  input,
  status
})
