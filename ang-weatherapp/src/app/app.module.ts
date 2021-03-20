import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { ReactiveFormsModule,FormsModule } from '@angular/forms';
import { UserComponent } from './user/user.component';
import { RegistrationComponent } from './user/registration/registration.component';
import { AuthenticationService } from './service/authentication.service';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { LoginComponent } from './user/login/login.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { HeaderComponent } from './header/header.component';
import { FooterComponent } from './footer/footer.component';
import { NewsComponent } from './news/news.component';
import { FavouriteComponent } from './favourite/favourite.component';
import { AuthInterceptor } from './auth/auth.interceptor';
import { SearchComponent } from './search/search.component';
import { DashboardScreenComponent } from './dashboard-screen/dashboard-screen.component';
//import { RecommendComponent } from './recommend/recommend.component';
import {AutocompleteLibModule} from 'angular-ng-autocomplete';
import { FavouriteListComponent } from './favourite-list/favourite-list.component';

@NgModule({
  declarations: [
    AppComponent,
    UserComponent,
    RegistrationComponent,
    LoginComponent,
    DashboardComponent,
    HeaderComponent,
    FooterComponent,
    NewsComponent,
    FavouriteComponent,
    SearchComponent,
    DashboardScreenComponent,
    FavouriteListComponent
        
    /*RecommendComponent,*/
    
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    NgbModule,
    ReactiveFormsModule,
    HttpClientModule,
    FormsModule,
    AutocompleteLibModule
  ],
   providers: [AuthenticationService],
 
  bootstrap: [AppComponent]
})
export class AppModule { }
