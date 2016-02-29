//import {ValidateCustomAttributeViewStrategy} from 'aurelia-validation';
// https://github.com/aurelia/validation/issues/165
import {TWBootstrapViewStrategy} from 'aurelia-validation/strategies/twbootstrap-view-strategy';

export function configure(aurelia) {
    aurelia.use
      .standardConfiguration()
      .developmentLogging()
      .plugin('aurelia-validation', (config) => { config.useViewStrategy(TWBootstrapViewStrategy.AppendToInput); });

    aurelia.start().then(() => aurelia.setRoot());
}