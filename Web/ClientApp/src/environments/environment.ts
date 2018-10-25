//import { production } from './environment.production';
//import { staging } from './environment.staging';
import { develop } from './environment.developer';

export const environment = {
    build: develop.build,
    name: develop.name,
    apiUrl: develop.apiUrl
};

//export const environment = {
//    build: production.build,
//    name: production.name,
//    apiUrl: production.apiUrl
//};
//export const environment = {
//    build: staging.build,
//    name: staging.name,
//    apiUrl: staging.apiUrl
//};