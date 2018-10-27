import { Observable } from "rxjs";

export class Helper {
  static booleanObservable(value: boolean): Observable<boolean> {
        return new Observable((observer) => {
            observer.next(value);
        });
    }
}