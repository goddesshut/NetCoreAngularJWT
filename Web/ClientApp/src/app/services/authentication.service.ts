import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Router } from "@angular/router";
import { AuthenticationModel } from "../models/authentication.model";
import { TokenService } from "../shared/services/token.service";
import { environment } from '../../environments/environment';

@Injectable({ providedIn: "root" })
export class AuthenticationService {

    private service = environment.apiUrl + "auth";

	constructor(
		private readonly http: HttpClient,
		private readonly router: Router,
		private readonly tokenService: TokenService) { }

    authenticate(authentication: AuthenticationModel) {
        this.http.post(`${this.service}/login`, authentication).subscribe((response: any) => {
			this.tokenService.set(response.token);
			this.router.navigate(["/home"]);
		});
	}

	isAuthenticated(): boolean {
		return this.tokenService.exists();
	}

	logout() {
		if (this.isAuthenticated()) {
			this.http.post(`${this.service}/logout`, {}).subscribe();
		}

		this.tokenService.clear();
		this.router.navigate(["/login"]);
	}
}
