import { Component, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Component({
    selector: 'app-registration',
    templateUrl: './registration.component.html'
})
export class RegistrationComponent {

    submitted = false;

    model = new RegistrationRequest("e", "e", "e", "e", "s");

    http: HttpClient;
    baseUrl: string;

    constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
        this.http = http;
        this.baseUrl = baseUrl;
        this.model = new RegistrationRequest("", "", "", "", "");
        /*
            http.post<RegistrationRequest>(baseUrl + 'registration',)
            http.get<WeatherForecast[]>(baseUrl + 'weatherforecast').subscribe(result => {
              this.forecasts = result;
            }, error => console.error(error));*/
    }

    onSubmit() {
        this.http.post(this.baseUrl + 'registration', this.model, { responseType: 'json' })
            .subscribe(res => {
                console.log(res);
                this.submitted = false;
            },
                err => {
                    console.log(err);
                    this.submitted = false;
                });
    }

    // TODO: Remove this when we're done
    get diagnostic() { return JSON.stringify(this.model); }

}

class RegistrationRequest {
    constructor(
        public companyName: string,
        public contactPerson: string,
        public email: string,
        public address: string,
        public licenseKey: string) { }
}
