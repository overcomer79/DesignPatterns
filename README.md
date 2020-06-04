# DesignPatterns

### Violate Open-closed principle
Because the open closed principle states that classes should be open for extension which means it should be possible to extend the product filter.
It should be possible to make new filters, but they should be closed for modification which means nobody should be going back into the filter and actually editing the code which is already there because we can assume that the filter might have already been shipped to a customer.