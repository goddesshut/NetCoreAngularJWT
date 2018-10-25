import { Observable } from "rxjs";
import { publishReplay, refCount, take } from "rxjs/operators";

export const cache = (observable: Observable<object>) =>
	observable.pipe(publishReplay(1), refCount(), take(1));
