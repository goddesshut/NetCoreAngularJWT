import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { cache } from "../shared/utils/rxjs.utils";

@Injectable({ providedIn: "root" })
export class ApplicationService {
	data: any;
	service = "ApplicationService";

	constructor(private readonly http: HttpClient) { }

	get() {
		if (!this.data) {
			this.data = this.http.get(this.service).pipe(cache);
		}

		return this.data;
	}
}
