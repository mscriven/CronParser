# CronParser




# ToDo

[] Convert to uint to avoid negative numbers natively and resolve edge cases.
[] Use dependency injection to avoid static calls, duplicated code, and general goodness.
[] Add support for month names. Ran out of time.
[] Potential opportunity to have each symbol parser be it's own strategy, and build a bag of valid strategies for each applicable token. Perhaps might be able to get away with a base class, and overrides for the extra weirdness for each token.